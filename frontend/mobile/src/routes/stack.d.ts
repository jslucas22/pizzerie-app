import { NativeStackNavigationProp } from "@react-navigation/native-stack";

export type RootStackParamList = {
  Home: undefined;
  Login: undefined;
};

export type AppNavigationProps = NativeStackNavigationProp<RootStackParamList>;
