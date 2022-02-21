import { IUser } from "./i-user";

export interface IUserList {
  count: number;
  next: string;
  previous: string;
  results: IUser[];
}