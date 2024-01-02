import React, { useState } from "react";

import * as S from "./styles";
import ProductHeader from "./header";
import Input from "components/Input";
import Spacer from "components/Spacer";
import Button from "components/Button";
import SelectInput from "components/SelectInput";

const ProductForm: React.FC = () => {
  const [category, setCategory] = useState<string>("");

  return (
    <S.Container>
      <ProductHeader />
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
          setCategory(v.value);
        }}
        placeholder="Selecione uma opção..."
      />
      <Spacer height={12} />
      <Input label="Descrição" observation />
      <Spacer height={12} />
      <Input label="Preço" />
      <Spacer height={28} />

      <S.Footer>
        <Button value="Salvar" />
        <Spacer height={12} />
        <Button value="Cancelar" outline />
      </S.Footer>
    </S.Container>
  );
};

export default ProductForm;
