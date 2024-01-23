export interface Product {
  Id: string;
  Description: string;
  Price: number;
  Category: "Pizza" | "Drink";
  CreatedAt?: Date;
}
