import React from "react";

import createHeader from "../components/Header";
import { createNativeStackNavigator } from "@react-navigation/native-stack";

import Home from "../screens/Home";
import Login from "../screens/Login";

import { useSafeAreaInsets } from "react-native-safe-area-context";
import { useTheme } from "styled-components/native";
import { RootStackParamList } from "./stack";
import Settings from "../screens/Settings";
import Checkouts from "../screens/Checkouts";
import Menu from "../screens/Menu";

const Stack = createNativeStackNavigator<RootStackParamList>();

export const StackRoutes: React.FC = () => {
  const theme = useTheme();
  const inset = useSafeAreaInsets();

  const initialRoute: keyof RootStackParamList = "Login";

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
        name="Checkouts"
        component={Checkouts}
        options={{ headerTitle: "Comandas" }}
      />
      <Stack.Screen
        name="Menu"
        component={Menu}
        options={{ headerTitle: "Cardápio" }}
      />
    </Stack.Navigator>
  );
};
