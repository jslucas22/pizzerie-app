import React from "react";

import Icon from "../../Icon";

import { useTheme } from "styled-components/native";
import * as S from "./styles";

interface TitleProps {
  name: string;
  onClose: () => void;
}

const Title: React.FC<TitleProps> = ({ name, onClose }) => {
  const theme = useTheme();

  return (
    <S.Container>
      <S.Text>{name}</S.Text>
      <Icon
        type="ionicons"
        name="md-close-outline"
        size={20}
        right={false}
        color={theme.colors.text.secondary}
        onPress={onClose}
      />
    </S.Container>
  );
};

export default Title;
