import { AuthorModel } from "./author.model";
import { GenderModel } from "./gender.model";

export interface BookModel {
    id: string,
    createAt?: Date,
    name: string,
    pages: number,
    language: string,    
    edition: number,
    isbn: string,
    gender?: GenderModel,
    author?: AuthorModel
}

export interface BookModelRequest {
    id: string,
    createAt?: Date,
    name: string,
    pages: number,
    language: string,    
    edition: number,
    isbn: string,
    genderId: string,
    authorId: string
}