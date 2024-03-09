import { IGenericEntity } from "./IGenericEntity";

export interface IPersona extends IGenericEntity {

    nombre:string;
    apellido:string;
    dni:number;

}