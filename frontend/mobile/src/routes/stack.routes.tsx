import React from "react";

import createHeader from "components/Header";
import { createNativeStackNavigator } from "@react-navigation/native-stack";

import Home from "screens/Home";
import Menu from "screens/Menu";
import Desks from "screens/Desks";
import Login from "screens/Login";
import Products from "screens/Products";
import Settings from "screens/Settings";
import Employees from "screens/Employees";
import ProductForm from "screens/ProductForm";
import EmployeeForm from "screens/EmployeeForm";

import { useSafeAreaInsets } from "react-native-safe-area-context";
import { useTheme } from "styled-components/native";
import { RootStackParamList } from "./stack";
import Orders from "screens/Orders";

const Stack = createNativeStackNavigator<RootStackParamList>();

export const StackRoutes: React.FC = () => {
  const theme = useTheme();
  const inset = useSafeAreaInsets();

  const initialRoute: keyof RootStackParamList = "Home";

  return (
    <Stack.Navigator
      initialRouteName={initialRoute}
      screenOptions={{
        headerStyle: {
          backgroundColor: theme.colors.header.backgroundColor,
        },
        headerTintColor: theme.colors.text.secondary,
        headerShadowVisible: true,
        animation: "slide_from_right",
        contentStyle: {
          backgroundColor: theme.colors.background,
        },
        header: createHeader(inset),
      }}
    >
      <Stack.Screen
        name="Login"
        component={Login}
        options={{ headerShown: false }}
      />
      <Stack.Screen
        name="Home"
        component={Home}
        options={{ headerShown: false }}
      />
      <Stack.Screen
        name="Settings"
        component={Settings}
        options={{ headerTitle: "Configurações" }}
      />
      <Stack.Screen
        name="Desks"
        component={Desks}
        options={{ headerTitle: "Selecionar mesa" }}
      />
      <Stack.Screen
        name="Menu"
        component={Menu}
        options={{ headerTitle: "Cardápio" }}
      />
      <Stack.Screen
        name="ProductForm"
        component={ProductForm}
        options={{ headerShown: false }}
      />
      <Stack.Screen
        name="EmployeeForm"
        component={EmployeeForm}
        options={{ headerShown: false }}
      />
      <Stack.Screen
        name="Employees"
        component={Employees}
        options={{ headerShown: false }}
      />
      <Stack.Screen
        name="Products"
        component={Products}
        options={{ headerShown: false }}
      />
      <Stack.Screen
        name="Orders"
        component={Orders}
        options={{ headerTitle: "Pedidos" }}
      />
    </Stack.Navigator>
  );
};
