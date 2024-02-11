import { NativeStackNavigationProp } from "@react-navigation/native-stack";

export type RootStackParamList = {
  Desks: undefined | { newDesk?: boolean };
  EmployeeForm: { id?: number } | undefined;
  Employees: undefined;
  FinishOrders: undefined;
  Home: undefined;
  Login: undefined;
  Menu: undefined;
  Order: { id: ?number } | undefined;
  Orders: undefined;
  ProductForm: { id?: number } | undefined;
  Products: undefined;
  Settings: undefined;
};

export type AppNavigationProps = NativeStackNavigationProp<RootStackParamList>;
