import { Product } from "./product";

export interface employeeCheckpad {
  Id: string;
  EmployeeName: string;
  Clients: string[];
  Products: Product[];
  Creation: Date;
  LastChangeDate: Date;
}
