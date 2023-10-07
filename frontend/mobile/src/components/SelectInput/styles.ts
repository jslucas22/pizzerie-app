import { RFValue } from 'react-native-responsive-fontsize'
import styled from 'styled-components/native'

export const Container = styled.View<{ width?: number }>`
  width: ${p => p.width ?? 100}%;
`

export const Label = styled.Text<{ secondary?: boolean }>`
  width: 100%;
  color: ${({ theme, secondary }) =>
    secondary ? theme.colors.text.secondary : theme.colors.text.primary};
  font-family: ${({ theme }) => theme.fonts.regular};
  font-size: ${RFValue(15)}px;
  text-align: left;
`

export const Button = styled.TouchableOpacity.attrs({
  elevation: 1,
  shadowOffset: { width: 0, height: 1 },
  shadowOpacity: 0.2,
  shadowColor: '#171717'
})`
  width: 100%;
  height: 46px;
  border-radius: 4px;
  background-color: ${({ theme, disabled }) =>
    !disabled
      ? theme.colors.input.backgroundColor
      : theme.colors.input.disabled};
  padding: 10px 9px;
  flex-direction: row;
  justify-content: space-between;
  align-items: center;
`

export const ButtonText = styled.Text.attrs({
  numberOfLines: 1,
  ellipsizeMode: 'tail'
})<{ hasText?: boolean }>`
  width: 90%;
  font-size: ${RFValue(12)}px;
  font-family: ${({ theme }) => theme.fonts.regular};
  color: ${({ theme, hasText }) =>
    hasText ? theme.colors.text.secondary : theme.colors.input.placeholder};
`
