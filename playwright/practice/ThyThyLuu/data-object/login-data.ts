import { LoginModel } from "../models/login-model";

export class LoginData implements LoginModel {
    username: string;
    password: string;

    constructor(data: LoginModel) {
        this.username = data.username ?? "";
        this.password = data.password ?? "";
    }
}