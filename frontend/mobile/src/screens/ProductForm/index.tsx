import React, { useState } from "react";

import Input from "components/Input";
import Spacer from "components/Spacer";
import Button from "components/Button";
import SelectInput from "components/SelectInput";

import { ScreenBaseProps } from "utils/index";

import ProductHeader from "./header";
import * as S from "./styles";

const ProductForm: React.FC<ScreenBaseProps<"ProductForm">> = ({
  navigation,
  route,
}) => {
  const [category, setCategory] = useState<string>("");

  return (
    <>
      <ProductHeader onGoBack={navigation.goBack} id={route.params?.id} />
      <S.Container>
        <Input label="Nome do Produto" />
        <Spacer height={12} />
        <SelectInput
          label="Categoria"
          value={category}
          items={[
            { label: "Pizzas", value: "P" },
            { label: "Bebidas", value: "B" },
          ]}
          onValueChange={(v) => {
            if (v) {
              setCategory(v.value);
            }
          }}
          placeholder="Selecione uma opção..."
        />
        <Spacer height={12} />
        <Input label="Descrição" />
        <Spacer height={12} />
        <Input label="Preço" />
        <Spacer height={28} />

        <S.Footer>
          <Button value="Salvar" />
          <Spacer height={12} />
          <Button value="Cancelar" outline />
        </S.Footer>
      </S.Container>
    </>
  );
};

export default ProductForm;
