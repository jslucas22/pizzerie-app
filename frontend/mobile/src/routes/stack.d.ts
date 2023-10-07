import { NativeStackNavigationProp } from "@react-navigation/native-stack";

export type RootStackParamList = {
  Checkouts: undefined;
  Home: undefined;
  Login: undefined;
  Menu: undefined;
  Order: undefined;
  Settings: undefined;
};

export type AppNavigationProps = NativeStackNavigationProp<RootStackParamList>;
