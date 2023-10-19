/* eslint-disable @typescript-eslint/no-unused-vars */
/* eslint-disable jsx-a11y/alt-text */
import React from "react";

import HomeHeader from "./header";

import { useTheme } from "styled-components/native";
import { ScreenBaseProps } from "../../utils";
import * as S from "./styles";
import { Alert } from "react-native";
import OptionsCard from "../../components/OptionsCard";

type Props = ScreenBaseProps<"Home">;

const Home: React.FC<Props> = ({ navigation }) => {
  const theme = useTheme();

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
        <OptionsCard
          name="Configurações"
          icon={{ name: "gears", type: "fontAwesome", size: 24 }}
          onPress={() => navigation.navigate("Settings")}
        />
      </S.Container>
    </>
  );
};

export default Home;
