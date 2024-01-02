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
    Login: "manobrown",
    Name: "Mano Brown",
    Senha: "1234",
    TipoUsuario: "ADMSYS",
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
        {user.TipoUsuario === "ADMSYS" ? (
          <>
            <OptionsCard
              name="Adicionar Funcionário"
              icon={{ name: "group-add", type: "material", size: 24 }}
              onPress={() => navigation.navigate("Menu")}
            />
            <OptionsCard
              name="Adicionar Produto"
              icon={{ name: "library-add", type: "material", size: 24 }}
              onPress={() => navigation.navigate("Desks")}
            />
            <OptionsCard
              name="Finalizar Pedido"
              icon={{ name: "library-add-check", type: "material", size: 24 }}
              onPress={() => navigation.navigate("Desks", { newDesk: true })}
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
