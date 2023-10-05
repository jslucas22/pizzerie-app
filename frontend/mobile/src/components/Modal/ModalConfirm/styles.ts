import { StyleSheet } from 'react-native'
import styled from 'styled-components/native'
import { RFValue } from 'react-native-responsive-fontsize'

export const Container = styled.View`
  display: flex;
  justify-content: center;
  border-radius: 6px;
  padding: 15px 0;
  background-color: ${({ theme }) => theme.colors.background};
`

export const TitleText = styled.Text`
  width: 90%;
  align-self: center;
  text-align: center;
  font-size: ${RFValue(15)}px;
  font-family: ${({ theme }) => theme.fonts.medium};
  color: ${({ theme }) => theme.colors.text.secondary};
`

export const SubText = styled.Text`
  width: 90%;
  align-self: center;
  text-align: center;
  margin-top: 10px;
  font-size: ${RFValue(14)}px;
  font-family: ${({ theme }) => theme.fonts.regular};
  color: ${({ theme }) => theme.colors.text.secondary};
`

export const RowView = styled.View`
  margin-top: 15px;
  border-radius: 6px;

  display: flex;
  flex-direction: row;
  justify-content: space-around;

  background-color: ${({ theme }) => theme.colors.background};
`

interface Props {
  isConfirm: boolean
}

export const OptBtn = styled.TouchableOpacity<Props>`
  width: 40%;

  padding: 5px;

  border-radius: 4px;
  background: ${({ isConfirm, theme }) =>
    isConfirm ? theme.colors.status.success : theme.colors.status.error};
`

export const OptBtnText = styled.Text<Props>`
  align-self: center;
  margin: 5px;

  text-align: center;
  font-size: ${RFValue(16)}px;
  font-family: ${({ theme }) => theme.fonts.medium};
  color: ${({ theme }) => theme.colors.text.primary};
`

export const styles = StyleSheet.create({
  shadow: {
    shadowColor: '#000',
    shadowOffset: {
      width: 0,
      height: 1
    },
    shadowOpacity: 0.2,
    shadowRadius: 1.41,

    elevation: 2
  }
})
