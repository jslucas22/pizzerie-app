import React from "react";

import * as S from "./styles";
import { Employee } from "definitions/employee";
import { View } from "react-native";
import Spacer from "components/Spacer";
import { Shadows } from "components/Shadows";
import Icon from "components/Icon";
import { useTheme } from "styled-components/native";

type Props = {
  employee: Employee;
};

const EmployeeCard: React.FC<Props> = ({ employee }) => {
  const theme = useTheme();

  return (
    <Shadows height="100">
      <S.Container>
        <View
          style={{
            width: 90,
            height: "100%",
            alignItems: "center",
            justifyContent: "center",
            backgroundColor: theme.colors.primary,
          }}
        >
          <Icon
            name="???"
            type="fontAwesome5"
            size={50}
            right={false}
            color={theme.colors.card}
            disabled
          />
        </View>
        <S.Content>
          <S.Title>
            {employee.Id} - {employee.Name}
          </S.Title>
          <Spacer height={14} />
          <S.Subtitle>Login: {employee.Login}</S.Subtitle>
          <Spacer height={8} />
          <S.Subtitle>Tipo Usuário: R${employee.TipoUsuario}</S.Subtitle>
          <Spacer height={8} />
        </S.Content>
      </S.Container>
    </Shadows>
  );
};

export default EmployeeCard;
