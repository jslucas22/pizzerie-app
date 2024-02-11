export interface Employee {
  Id: number;
  Uuid: string;
  Name: string;
  Username: string;
  Password: string;
  LevelId?: number;
  CreatedAt?: Date;
  UpdatedAt?: Date;
}
