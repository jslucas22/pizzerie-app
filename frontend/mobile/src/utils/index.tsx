import { NativeStackScreenProps } from "@react-navigation/native-stack";
import { RootStackParamList } from "routes/stack";

export type ScreenBaseProps<T extends keyof RootStackParamList> =
  NativeStackScreenProps<RootStackParamList, T>;
