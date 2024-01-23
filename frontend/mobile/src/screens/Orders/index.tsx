import React from "react";
import { FlatList } from "react-native";

import OrderCard from "components/OrderCard";

import { Order } from "definitions/order";
import { ScreenBaseProps } from "utils/index";

import * as S from "./styles";

const Orders: React.FC<ScreenBaseProps<"Orders">> = ({ navigation }) => {
  const employees: Order[] = [
    {
      Id: "1",
      CustomerName: "John",
      CreatedAt: new Date(),
      EmployeeId: "Sam",
      UpdatedAt: new Date(),
      Products: [],
    },
  ];

  return (
    <S.Container>
      <FlatList
        data={employees}
        renderItem={({ item }) => (
          <OrderCard
            order={item}
            onPress={() => navigation.navigate("Order", { id: item.Id })}
          />
        )}
        style={{ paddingHorizontal: 24, paddingVertical: 16 }}
      />
    </S.Container>
  );
};

export default Orders;
