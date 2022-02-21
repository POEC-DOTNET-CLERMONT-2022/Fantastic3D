import { User } from "./user";

export interface IUserList {
  count: number;
  next: string;
  previous: string;
  results: User[];
}
