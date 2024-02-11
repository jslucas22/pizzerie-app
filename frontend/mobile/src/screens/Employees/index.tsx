import React from "react";
import { FlatList } from "react-native";

import EmployeeCard from "components/Cards/EmployeeCard";

import { Employee } from "definitions/employee";
import { ScreenBaseProps } from "utils/index";

import EmployeesHeader from "./header";
import * as S from "./styles";

const Employees: React.FC<ScreenBaseProps<"Employees">> = ({ navigation }) => {
  const employees: Employee[] = [
    {
      Id: 1,
      Uuid: 'dghaksdghashdajksndjknhajkshdjkah',
      Name: "Administrador",
      Username: "admin",
      Password: "123456",
      LevelId: 2,
    },
  ];

  return (
    <>
      <EmployeesHeader
        onGoBack={navigation.goBack}
        onAdd={() => navigation.navigate("EmployeeForm")}
      />
      <S.Container>
        <FlatList
          data={employees}
          renderItem={({ item }) => (
            <EmployeeCard
              employee={item}
              onPress={() =>
                navigation.navigate("EmployeeForm", { id: item.Id })
              }
            />
          )}
          style={{ paddingHorizontal: 24, paddingVertical: 16 }}
        />
      </S.Container>
    </>
  );
};

export default Employees;
