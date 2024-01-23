import React, { useCallback, useEffect, useState } from "react";
import Toast from "react-native-root-toast";

import Input from "components/Input";
import Spacer from "components/Spacer";
import Button from "components/Button";
import Loading from "components/Loading";
import ErrorPage from "components/ErrorPage";

import { ScreenBaseProps } from "utils/index";
import { useTheme } from "styled-components/native";

import * as S from "./styles";

const Settings: React.FC<ScreenBaseProps<"Settings">> = ({
  navigation,
  route,
}) => {
  const theme = useTheme();

  const [desks, setDesks] = useState(0);
  const [loading, setLoading] = useState(false);

  const getDesks = useCallback(async () => {}, []);

  useEffect(() => {
    getDesks();
  }, [getDesks]);

  const handleSaveDesks = async () => {
    setLoading(true);
    try {
      Toast.show("Configuração salva com sucesso!", {
        backgroundColor: theme.colors.status.active,
      });
      navigation.goBack();
    } catch (error) {
      return <ErrorPage message={(error as Error).message} />;
    }
  };

  if (loading) {
    return <Loading overlap />;
  }

  return (
    <S.Container>
      <Input
        label="Número de mesas:"
        value={desks.toString()}
        onChangeText={(s) => setDesks(Number(s))}
        textAlign="center"
        keyboardType="numeric"
      />
      <Spacer height={24} />
      <Button value="Salvar alterações" onPress={handleSaveDesks} />
    </S.Container>
  );
};

export default Settings;
