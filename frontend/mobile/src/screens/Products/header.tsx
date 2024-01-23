import React from "react";

import { useSafeAreaInsets } from "react-native-safe-area-context";

import Icon from "components/Icon";
import { CText } from "components/headers/headerStyle";
import HeaderContainer from "components/headers/headerContainer";

import { useTheme } from "styled-components/native";

interface Props {
  onAdd?: () => void;
  onGoBack?: () => void;
}

const ProductsHeader: React.FC<Props> = ({ onAdd, onGoBack }) => {
  const theme = useTheme();
  const insets = useSafeAreaInsets();

  return (
    <HeaderContainer insetTop={insets.top}>
      <Icon
        type="feather"
        name="arrow-left"
        size={30}
        right={false}
        onPress={onGoBack}
        color={theme.colors.text.secondary}
      />
      <CText>Produtos</CText>
      <Icon
        type="antdesign"
        name="plus"
        size={30}
        right={false}
        onPress={onAdd}
        color={theme.colors.text.secondary}
      />
    </HeaderContainer>
  );
};

export default ProductsHeader;
