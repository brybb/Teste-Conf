import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { AbstractControlOptions, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { first } from 'rxjs/operators';
import { Schooling } from '@app/_models';

import { UserService, AlertService, SchoolingService } from '@app/_services';

import { MustMatch } from '@app/_helpers';

@Component({ templateUrl: 'add-edit.component.html' })
export class AddEditComponent implements OnInit {
    form!: FormGroup;
    id!: string;
    escolaridades!: Schooling[];
    selectedFile!: File;
    isAddMode!: boolean;
    loading = false;
    submitted = false;
    

    constructor(
        private formBuilder: FormBuilder,
        private route: ActivatedRoute,
        private userService: UserService,
        private alertService: AlertService,
        private schoolingService: SchoolingService,
        private router: Router
    ) {}

    ngOnInit() {
        this.id = this.route.snapshot.params['id'];
        this.isAddMode = !this.id;

        // password not required in edit mode
        const passwordValidators = [Validators.minLength(6)];
        if (this.isAddMode) {
            passwordValidators.push(Validators.required);
        }
          
       
        this.schoolingService.getAll().subscribe(data => {
           this.escolaridades = data
        });

        const formOptions: AbstractControlOptions = {};
        this.form = this.formBuilder.group({
            nome: ['', Validators.required],
            sobrenome: ['', Validators.required],
            email: ['', [Validators.required, Validators.email]],
            escolaridadeId: ['', Validators.required],
            dataNascimento: [''],
            filearq: null
        }, formOptions);


        if (!this.isAddMode) {
            this.userService.getById(this.id)
                .pipe(first())
                .subscribe(x => this.form.patchValue(x));

                
        }
    }

    // convenience getter for easy access to form fields
    get f() { return this.form.controls; }

    onSubmit() {
        this.submitted = true;

        // reset alerts on submit
        this.alertService.clear();

        // stop here if form is invalid
        if (this.form.invalid) {
            return;
        }

        this.loading = true;
        if (this.isAddMode) {
            this.createUser();
        } else {
            this.updateUser();
        }
    }

    handleFile($event : any) {
        
        const formData: FormData = new FormData();
        const files=$event.target.files[0];

        this.selectedFile = <File>$event.target.files[0];
    }

    private createUser() {
        console.log(this.form.value);

        const formData = new FormData();
        formData.append('nome', this.form.value.nome);
        formData.append('sobrenome', this.form.value.sobrenome);
        formData.append('email', this.form.value.email);
        formData.append('escolaridadeId', this.form.value.escolaridadeId);
        formData.append('dataNascimento', this.form.value.dataNascimento);
        formData.append('filearq', this.selectedFile);

        this.userService.create(formData)
            .pipe(first())
            .subscribe(() => {
                this.alertService.success('Usuário Adicionado', { keepAfterRouteChange: true });
                this.router.navigate(['../'], { relativeTo: this.route });
            })
            .add(() => this.loading = false);
    }

    private updateUser() {
        this.userService.update(this.id, this.form.value)
            .pipe(first())
            .subscribe(() => {
                this.alertService.success('Usuario atualizado', { keepAfterRouteChange: true });
                //this.router.navigate(['../../'], { relativeTo: this.route });
            })
            .add(() => this.loading = false);
    }

    private formatDate(date:string) {
        const d = new Date(date);
        let month = '' + (d.getMonth() + 1);
        let day = '' + d.getDate();
        const year = d.getFullYear();
        if (month.length < 2) month = '0' + month;
        if (day.length < 2) day = '0' + day;
        return [year, month, day].join('-');
      }
}