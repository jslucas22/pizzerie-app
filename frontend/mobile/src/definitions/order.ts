export interface Order {
  Id: number;
  Uuid: string;
  EmployeeId?: number;
  TableNumber: number;
  CustomerName: string;
  TotalValue: number;
  PaymentMethod: string;
  Status: string;
  Note?: string;
  CreatedAt?: Date;
  UpdatedAt?: Date;
}
