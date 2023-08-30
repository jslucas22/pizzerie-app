export type Comanda = {
  id: string;
  id_employee: string;
  client_name: string;
  products: [
    {
      id: string;
    }
  ];
  creation_date: Date;
};
