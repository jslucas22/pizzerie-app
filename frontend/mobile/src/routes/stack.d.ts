import { NativeStackNavigationProp } from "@react-navigation/native-stack";

export type RootStackParamList = {
  Desks: undefined | { newDesk?: boolean };
  Home: undefined;
  Login: undefined;
  Menu: undefined;
  Order: undefined;
  Settings: undefined;
};

export type AppNavigationProps = NativeStackNavigationProp<RootStackParamList>;
