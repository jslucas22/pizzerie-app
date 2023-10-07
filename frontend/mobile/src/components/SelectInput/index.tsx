import React from "react";

import Icon from "../Icon";

import { useTheme } from "styled-components/native";
import * as S from "./styles";

interface SelectInputProps {
  value?: string;
  disabled?: boolean;
  label?: string;
  labelSecondary?: boolean;
  width?: number;
  onPress?: () => void;
  onRemove?: () => void;
}

const SelectInput: React.FC<SelectInputProps> = ({
  value,
  label,
  disabled,
  labelSecondary,
  width,
  onPress,
  onRemove,
}) => {
  const theme = useTheme();
  return (
    <S.Container width={width}>
      <S.Label secondary={labelSecondary}>{!!label ? label : ""}</S.Label>
      <S.Button disabled={disabled} onPress={onPress} activeOpacity={0.89}>
        <S.ButtonText hasText={!!value}>
          {!!value ? value : "Escolha..."}
        </S.ButtonText>
        <Icon
          type="entypo"
          name="cross"
          size={20}
          disabled={disabled}
          onPress={onRemove}
          color={
            disabled ? theme.colors.disabled : theme.colors.input.placeholder
          }
        />
      </S.Button>
    </S.Container>
  );
};

export default SelectInput;
