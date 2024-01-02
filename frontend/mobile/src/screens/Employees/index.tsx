import React from "react";

import * as S from "./styles";
import { FlatList } from "react-native-gesture-handler";
import EmployeeCard from "components/EmployeeCard";
import { Employee } from "definitions/employee";
import EmployeeHeader from "screens/EmployeeForm/header";

const Employees: React.FC = () => {
  const products: Employee[] = [
    {
      Id: "1",
      Name: "Administrador",
      Login: "admin",
      Senha: "123456",
      TipoUsuario: "ADMSYS",
    },
  ];

  return (
    <S.Container>
      <EmployeeHeader />
      <FlatList
        data={products}
        renderItem={(item) => <EmployeeCard employee={item.item} />}
        style={{ paddingHorizontal: 24, paddingVertical: 16 }}
      />
    </S.Container>
  );
};

export default Employees;
