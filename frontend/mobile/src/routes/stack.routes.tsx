import createHeader from "components/Header";
import { createNativeStackNavigator } from "@react-navigation/native-stack";

import Home from "screens/Home";

import { useSafeAreaInsets } from "react-native-safe-area-context";
import { useTheme } from "styled-components/native";
import { RootStackParamList } from "./stack";

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
        name="Home"
        component={Home}
        options={{ headerShown: false }}
      />
    </Stack.Navigator>
  );
};