export interface Product {
  Id: number;
  Uuid: string;
  Description: string;
  Price: number;
  Category: "Pizza" | "Drink";
  CreatedAt?: Date;
  UpdatedAt?: Date;
}
