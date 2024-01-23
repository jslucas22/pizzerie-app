/* eslint-disable @typescript-eslint/no-unused-vars */
/* eslint-disable jsx-a11y/alt-text */
import React from "react";

import HomeHeader from "./header";

import { useTheme } from "styled-components/native";
import { ScreenBaseProps } from "utils/index";
import * as S from "./styles";
import { Alert } from "react-native";
import OptionsCard from "components/OptionsCard";
import { Employee } from "definitions/employee";

const Home: React.FC<ScreenBaseProps<"Home">> = ({ navigation }) => {
  const theme = useTheme();

  const user: Employee = {
    Id: "hsdjashdaskhdakjshd",
    Username: "manobrown",
    Name: "Mano Brown",
    Password: "1234",
    LevelId: 2,
  };

  const handleLogout = () => {
    Alert.alert("SAIR", "Deseja sair da sua conta?", [
      { text: "Sim", onPress: () => navigation.replace("Login") },
      { text: "Não" },
    ]);
  };

  return (
    <>
      <HomeHeader
        onExit={() => {
          handleLogout();
        }}
      />
      <S.Container>
        {user.LevelId === 2 ? (
          <>
            <OptionsCard
              name="Ver Funcionários"
              icon={{ name: "group-add", type: "material", size: 24 }}
              onPress={() => navigation.navigate("Employees")}
            />
            <OptionsCard
              name="Ver Produtos"
              icon={{ name: "library-add", type: "material", size: 24 }}
              onPress={() => navigation.navigate("Products")}
            />
            <OptionsCard
              name="Ver Pedidos"
              icon={{ name: "library-add-check", type: "material", size: 24 }}
              onPress={() => navigation.navigate("Orders")}
            />
            <OptionsCard
              name="Configurações"
              icon={{ name: "gears", type: "fontAwesome", size: 24 }}
              onPress={() => navigation.navigate("Settings")}
            />
          </>
        ) : (
          <>
            <OptionsCard
              name="Ver Cardápio"
              icon={{ name: "menu-book", type: "material", size: 24 }}
              onPress={() => navigation.navigate("Menu")}
            />
            <OptionsCard
              name="Ver Comandas"
              icon={{ name: "cards", type: "material-community", size: 24 }}
              onPress={() => navigation.navigate("Desks")}
            />
            <OptionsCard
              name="Novo Pedido"
              icon={{ name: "plus", type: "fontAwesome", size: 24 }}
              onPress={() => navigation.navigate("Desks", { newDesk: true })}
            />
          </>
        )}
      </S.Container>
    </>
  );
};

export default Home;
