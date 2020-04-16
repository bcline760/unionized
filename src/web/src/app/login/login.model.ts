import { SessionService } from "../service/session.service";

export class LoginModel {
    username:string;
    password:string;
    remember:boolean;

    constructor(private session:SessionService){

    }

    authenticate():void {
        
    }
}
