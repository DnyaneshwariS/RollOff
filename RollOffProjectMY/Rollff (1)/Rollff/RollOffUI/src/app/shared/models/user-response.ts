export interface IUserAuthenticateResponse {
  id: number;
  name: string;
  email: string;
  role: string;
  token: string;
  validTo: string;
}