/* eslint-disable @typescript-eslint/no-unused-vars */
/* eslint-disable jsx-a11y/alt-text */
import React from "react";

import HomeHeader from "./header";

import { useTheme } from "styled-components/native";
import { ScreenBaseProps } from "../../utils";
import * as S from "./styles";
import { Alert } from "react-native";

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
      <S.Container></S.Container>
    </>
  );
};

export default Home;
