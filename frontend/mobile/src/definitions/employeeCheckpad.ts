import { Product } from "./product";

export interface EmployeeCheckpad {
  Id: string;
  EmployeeName: string;
  Clients: string[];
  Products: Product[];
  Creation: Date;
  LastChangeDate: Date;
}
