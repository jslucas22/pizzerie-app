import { Product } from "./product";

export interface Order {
  Id: string;
  EmployeeId: number;
  TableNumber: number;
  CustomerName: string;
  TotalValue: number;
  PaymentMethod: string;
  Status: string;
  Note: string;

  Products: Product[];
  CreatedAt: Date;
  UpdatedAt: Date;
}
