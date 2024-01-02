import React from "react";

import RNPickerSelect from "react-native-picker-select";

import * as S from "./styles";

interface Item {
  label: string;
  value: string;
}

interface SelectInputProps {
  value?: any;
  disabled?: boolean;
  label?: string;
  labelSecondary?: boolean;
  width?: number;
  onValueChange: (value: any) => void;
  placeholder?: string;
  items: Item[];
}

const SelectInput: React.FC<SelectInputProps> = ({
  value,
  label,
  disabled,
  labelSecondary,
  width,
  onValueChange,
  placeholder,
  items,
}) => {
  return (
    <S.Container width={width}>
      <S.Label secondary={labelSecondary}>{!!label ? label : ""}</S.Label>
      <RNPickerSelect
        onValueChange={onValueChange}
        disabled={disabled}
        value={value}
        placeholder={placeholder}
        items={items}
      />
    </S.Container>
  );
};

export default SelectInput;
