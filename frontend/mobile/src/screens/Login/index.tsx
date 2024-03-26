/* eslint-disable jsx-a11y/alt-text */
import React, { useRef, useState } from "react";
import { TextInput, View } from "react-native";

import Toast from "react-native-root-toast";

import Icon from "components/Icon";
import Input from "components/Input";
import Button from "components/Button";
import Spacer from "components/Spacer";
import Version from "components/Version";
import InputPassword from "components/InputPassword";

import { focusNextInput, ScreenBaseProps } from "utils/index";
import { useTheme } from "styled-components/native";
import * as S from "./styles";
import { Employee } from "definitions/employee";
import { useMe } from "providers/user";
import { showToast } from "utils/toast";

type Props = ScreenBaseProps<"Login">;

const Login: React.FC<Props> = ({ navigation }) => {
  const { setUser, setToken } = useMe()
  const theme = useTheme();

  const passRef = useRef<TextInput>(null);
  const [login, setLogin] = useState("");
  const [password, setPassword] = useState("");
  const [loading, setLoading] = useState(false);

  const handleLogin = async () => {
    setLoading(true);
    try {
      const user: Employee = {
        Id: 1,
        Uuid: 'hasdahsadhsashd',
        Username: "manobrown",
        Name: "Mano Brown",
        Password: "1234",
        LevelId: 2,
      };
      setUser(user);
      setToken("dasdakshkdhakjdhjahsdhahsd")
      showToast('success', "Login realizado com sucesso!");
      navigation.navigate("Home");
    } catch (error) {
      const msg = (error as Error).message
      showToast("error", msg)
    } finally {
      setLoading(false);
    }
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
          value={login}
          onChangeText={setLogin}
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
        <Spacer height={140} />
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
