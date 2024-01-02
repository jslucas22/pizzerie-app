import { RectButton } from "react-native-gesture-handler";
import { RFValue } from "react-native-responsive-fontsize";
import styled from "styled-components/native";

export const Container = styled(RectButton)`
  width: 100%;
  height: 100px;
  flex-direction: row;
  align-items: center;
  justify-content: center;
  border-radius: 16px;
  overflow: hidden;
`;

export const Content = styled.View`
  flex: 1;
  height: 100%;
  padding: 8px;
  background-color: ${({ theme }) => theme.colors.card};
`;

export const Title = styled.Text`
  font-family: ${({ theme }) => theme.fonts.semibold};
  font-size: ${RFValue(14)}px;
  line-height: ${RFValue(18)}px;
  color: ${({ theme }) => theme.colors.text.primary};
`;

export const Subtitle = styled.Text`
  font-family: ${({ theme }) => theme.fonts.regular};
  font-size: ${RFValue(12)}px;
  line-height: ${RFValue(16)}px;
  color: ${({ theme }) => theme.colors.text.primary};
`;
