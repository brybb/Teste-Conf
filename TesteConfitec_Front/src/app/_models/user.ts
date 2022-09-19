import { Role } from './role';
import { Schooling } from './schooling';

export class User {
    id!: string;
    nome!: string;
    sobrenome!: string;
    email!: string;
    role!: Role;
    escolaridade!: Schooling;
    isDeleting: boolean = false;
}