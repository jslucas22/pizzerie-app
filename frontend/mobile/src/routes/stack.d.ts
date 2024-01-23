import { NativeStackNavigationProp } from "@react-navigation/native-stack";

export type RootStackParamList = {
  Desks: undefined | { newDesk?: boolean };
  EmployeeForm: { id?: string } | undefined;
  Employees: undefined;
  FinishOrders: undefined;
  Home: undefined;
  Login: undefined;
  Menu: undefined;
  Order: { id: ?string } | undefined;
  Orders: undefined;
  ProductForm: { id?: string } | undefined;
  Products: undefined;
  Settings: undefined;
};

export type AppNavigationProps = NativeStackNavigationProp<RootStackParamList>;
