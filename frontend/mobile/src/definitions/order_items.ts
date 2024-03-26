export interface OrderItem {
    Id: number;
    OrderId?: number;
    ProductId?: number;
    Quantity: number;
    IdStatus: number;
    CreatedAt?: Date;
    UpdatedAt?: Date;
}