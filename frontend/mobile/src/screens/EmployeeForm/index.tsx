import React, { useState } from "react";
import { View } from "react-native";

import Input from "components/Input";
import Spacer from "components/Spacer";
import Button from "components/Button";
import SelectInput from "components/SelectInput";

import { ScreenBaseProps } from "utils/index";

import EmployeeHeader from "./header";
import * as S from "./styles";

const EmployeeForm: React.FC<ScreenBaseProps<"EmployeeForm">> = ({
  navigation,
  route,
}) => {
  const [userType, setUserType] = useState("");

  return (
    <>
      <EmployeeHeader onGoBack={navigation.goBack} id={route.params?.id} />
      <S.Container>
        <Input label="Nome Completo" />
        <Spacer height={12} />
        <Input label="Login" />
        <Spacer height={12} />
        <Input label="Senha" />
        <Spacer height={12} />
        <SelectInput
          label="Tipo Usuário"
          value={userType}
          items={[
            { label: "Administrador", value: "ADMSYS" },
            { label: "Funcionário", value: "EMPLOY" },
          ]}
          onValueChange={(v) => {
            if (v) {
              setUserType(v.value);
            }
          }}
          placeholder="Selecione uma opção..."
        />
        <Spacer height={28} />
        <View
          style={{ flex: 1, alignItems: "center", justifyContent: "flex-end" }}
        >
          <Button value="Salvar" />
          <Spacer height={12} />
          <Button value="Cancelar" outline />
        </View>
      </S.Container>
    </>
  );
};

export default EmployeeForm;
