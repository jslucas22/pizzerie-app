import React, { useCallback, useEffect, useState } from "react";

import * as S from "./styles";
import { ScreenBaseProps } from "../../utils";
import Input from "../../components/Input";
import Spacer from "../../components/Spacer";
import Button from "../../components/Button";
import { getSetting } from "../stored/settings/getSetting";
import Loading from "../../components/Loading";
import { saveSetting } from "../stored/settings/addSetting";
import Toast from "react-native-root-toast";
import { useTheme } from "styled-components/native";
import ErrorPage from "../../components/ErrorPage";

type Props = ScreenBaseProps<"Settings">;

const Settings: React.FC<Props> = ({ navigation, route }) => {
  const theme = useTheme();

  const [desks, setDesks] = useState(0);
  const [loading, setLoading] = useState(false);

  const getDesks = useCallback(async () => {
    const d = await getSetting();
    if (d.tables) {
      setDesks(d.tables);
    }
  }, []);

  useEffect(() => {
    getDesks();
  }, [getDesks]);

  const handleSaveDesks = async () => {
    setLoading(true);
    try {
      await saveSetting({ tables: desks });
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
      />
      <Spacer height={24} />
      <Button value="Salvar alterações" onPress={handleSaveDesks} />
    </S.Container>
  );
};

export default Settings;
