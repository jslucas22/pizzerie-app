import React from "react";

import * as S from "./styles";
import { ScreenBaseProps } from "../../utils";
import Input from "../../components/Input";

type Props = ScreenBaseProps<"Settings">;

const Settings: React.FC<Props> = ({ navigation, route }) => {
  return (
    <S.Container>
      <Input label="Número de mesas:" />
    </S.Container>
  );
};

export default Settings;
