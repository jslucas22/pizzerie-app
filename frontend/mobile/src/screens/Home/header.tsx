/* eslint-disable jsx-a11y/alt-text */
/* eslint-disable react-hooks/exhaustive-deps */
import React, { useCallback } from "react";
import { BackHandler, Image, View } from "react-native";

import { useFocusEffect } from "@react-navigation/native";
import { useSafeAreaInsets } from "react-native-safe-area-context";

import Icon from "../../components/Icon";
import Spacer from "../../components/Spacer";
import HeaderContainer from "../../components/headers/headerContainer";

import { useTheme } from "styled-components/native";
import * as S from "./styles";

interface Props {
  onExit: () => void;
}

const HomeHeader: React.FC<Props> = ({ onExit }) => {
  const theme = useTheme();
  const insets = useSafeAreaInsets();

  //Intercept back button behavior
  useFocusEffect(
    useCallback(() => {
      const handler = () => {
        openExitModal();
        return true;
      };

      const event = BackHandler.addEventListener("hardwareBackPress", handler);

      return () => event.remove();
    }, [])
  );

  const openExitModal = () => {
    onExit();
  };
  return (
    <HeaderContainer
      insetTop={insets.top}
      flexStart={true}
      style={{
        shadowColor: "#000",
        shadowOffset: {
          width: -2,
          height: 4,
        },
        shadowOpacity: 0.36,
        shadowRadius: 1.0,

        elevation: 6,
      }}
    >
      <View style={{ width: "100%", marginTop: 12 }}>
        <S.Title>Pizzeria APP</S.Title>
        <Spacer height={24} />
        <View
          style={{
            width: "100%",
            flexDirection: "row",
            justifyContent: "space-between",
            alignItems: "center",
            paddingRight: 8,
          }}
        >
          <S.User>
            Usuário: <S.User semibold>{"Administrador"}</S.User>
          </S.User>
          <Spacer width={8} />
          <Icon
            type="fontAwesome"
            name="power-off"
            size={20}
            right={false}
            color={theme.colors.text.secondary}
            onPress={openExitModal}
          />
        </View>
      </View>
    </HeaderContainer>
  );
};

export default HomeHeader;
