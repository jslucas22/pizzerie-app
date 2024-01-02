import React, { useState } from "react";

import * as S from "./styles";
import EmployeeHeader from "./header";
import Input from "components/Input";
import Spacer from "components/Spacer";
import Button from "components/Button";
import SelectInput from "components/SelectInput";

const EmployeeForm: React.FC = () => {
  const [userType, setUserType] = useState("");

  return (
    <S.Container>
      <EmployeeHeader />
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
          setUserType(v.value);
        }}
        placeholder="Selecione uma opção..."
      />
      <Spacer height={28} />
      <Button value="Salvar" />
      <Spacer height={12} />
      <Button value="Cancelar" outline />
    </S.Container>
  );
};

export default EmployeeForm;
