export enum UserRole {
    Admin,
    Premium,
    Basic
}

export class User {
    private _id: number = 0;
    private _username: string = '';
    private _firstName: string = '';
    private _lastName: string = '';
    private _email: string = '';
    private _password: string = '';
    private _billingAddress: string = '';
    private _role: UserRole = UserRole.Basic;

    get id() {
      return this._id
    }
    
    set id(val: number) {
      this._id = val
    }
    
    get username() {
      return this._username
    }
    
    set username(val: string) {
      this._username = val
    }
    
    get firstName() {
      return this._firstName
    }
    
    set firstName(val: string) {
      this._firstName = val
    }
    
    get lastName() {
      return this._lastName
    }
    
    set lastName(val: string) {
      this._lastName = val
    }
    
    get email() {
      return this._email
    }
    
    set email(val: string) {
      this._email = val
    }
    
    get password() {
      return this._password
    }
    
    set password(val: string) {
      this._password = val
    }
    
    get billingAddress() {
      return this._billingAddress
    }
    
    set billingAddress(val: string) {
      this._billingAddress = val
    }
    
    get role() {
      return this._role
    }
    
    set role(val: UserRole) {
      this._role = val
    }
    
}