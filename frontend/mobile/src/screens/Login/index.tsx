/* eslint-disable jsx-a11y/alt-text */
import React, { useRef, useState } from "react";
import { TextInput, View } from "react-native";

import Toast from "react-native-root-toast";

import Input from "components/Input";
import Button from "components/Button";
import Spacer from "components/Spacer";
import InputPassword from "components/InputPassword";

import { focusNextInput, ScreenBaseProps } from "utils/index";
import { useTheme } from "styled-components/native";
import Version from "components/Version";
import * as S from "./styles";
import Icon from "components/Icon";

type Props = ScreenBaseProps<"Login">;

const Login: React.FC<Props> = ({ navigation }) => {
  const theme = useTheme();
  const passRef = useRef<TextInput>(null);
  const [user, setUser] = useState("");
  const [password, setPassword] = useState("");
  const [loading, setLoading] = useState(false);

  const handleLogin = () => {
    Toast.show("Login realizado com sucesso!", {
      backgroundColor: theme.colors.secondary,
    });
    navigation.navigate("Home");
  };

  return (
    <S.Container>
      <S.Header>
        <View style={{ position: "absolute" }}>
          <Icon
            name="pizza-slice"
            type="fontAwesome5"
            size={120}
            right={false}
            color={theme.colors.card}
          />
          <S.HeaderText>Pizzeria APP</S.HeaderText>
        </View>
      </S.Header>
      <S.Content>
        <S.GreetingText>Acessar sistema</S.GreetingText>
        <S.LabelText>Insira as informações abaixo para acessar.</S.LabelText>
        <Spacer height={24} />
        <Input
          placeholder="Usuário"
          value={user}
          onChangeText={setUser}
          autoCapitalize="none"
          autoFocus
          onSubmitEditing={() => focusNextInput(passRef)}
        />
        <Spacer height={28} />
        <InputPassword
          placeholder="Senha"
          ref={passRef}
          value={password}
          autoCapitalize="none"
          onChangeText={setPassword}
          onSubmitEditing={() => {
            return;
          }}
        />
        <Spacer height={30} />
        <Button
          value="Login"
          onPress={() => {
            handleLogin();
          }}
          disabled={loading}
        />
        <Version />
      </S.Content>
    </S.Container>
  );
};

export default Login;
