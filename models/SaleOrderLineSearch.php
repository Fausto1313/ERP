<?php

namespace app\models;

use yii\base\Model;
use yii\data\ActiveDataProvider;
use app\models\SaleOrderLine;

class SaleOrderLineSearch extends SaleOrderLine
{
    public function rules()
    {
        return [
            [['id', 'order_id', 'sequence', 'product_id', 'product_uom', 'salesman_id', 'currency_id', 'company_id', 'order_partner_id', 'is_expense', 'is_downpayment', 'create_uid', 'write_uid', 'product_packaging', 'route_id', 'linked_line_id'], 'integer'],
            [['name', 'invoice_status', 'qty_delivered_method', 'state', 'display_type', 'create_date', 'write_date', 'warning_stock'], 'safe'],
            [['price_unit', 'price_subtotal', 'price_tax', 'price_total', 'price_reduce', 'price_reduce_taxinc', 'price_reduce_taxexcl', 'discount', 'product_uom_qty', 'qty_delivered', 'qty_delivered_manual', 'qty_to_invoice', 'qty_invoiced', 'untaxed_amount_invoiced', 'untaxed_amount_to_invoice', 'customer_lead'], 'number'],
        ];
    }

    public function scenarios()
    {
        return Model::scenarios();
    }

    public function search($params)
    {
        $query = SaleOrderLine::find();


        $dataProvider = new ActiveDataProvider([
            'query' => $query,
        ]);

        $this->load($params);

        if (!$this->validate()) {
            return $dataProvider;
        }

        $query->andFilterWhere([
            'id' => $this->id,
            'order_id' => $this->order_id,
            'sequence' => $this->sequence,
            'price_unit' => $this->price_unit,
            'price_subtotal' => $this->price_subtotal,
            'price_tax' => $this->price_tax,
            'price_total' => $this->price_total,
            'price_reduce' => $this->price_reduce,
            'price_reduce_taxinc' => $this->price_reduce_taxinc,
            'price_reduce_taxexcl' => $this->price_reduce_taxexcl,
            'discount' => $this->discount,
            'product_id' => $this->product_id,
            'product_uom_qty' => $this->product_uom_qty,
            'product_uom' => $this->product_uom,
            'qty_delivered' => $this->qty_delivered,
            'qty_delivered_manual' => $this->qty_delivered_manual,
            'qty_to_invoice' => $this->qty_to_invoice,
            'qty_invoiced' => $this->qty_invoiced,
            'untaxed_amount_invoiced' => $this->untaxed_amount_invoiced,
            'untaxed_amount_to_invoice' => $this->untaxed_amount_to_invoice,
            'salesman_id' => $this->salesman_id,
            'currency_id' => $this->currency_id,
            'company_id' => $this->company_id,
            'order_partner_id' => $this->order_partner_id,
            'is_expense' => $this->is_expense,
            'is_downpayment' => $this->is_downpayment,
            'customer_lead' => $this->customer_lead,
            'create_uid' => $this->create_uid,
            'create_date' => $this->create_date,
            'write_uid' => $this->write_uid,
            'write_date' => $this->write_date,
            'product_packaging' => $this->product_packaging,
            'route_id' => $this->route_id,
            'linked_line_id' => $this->linked_line_id,
        ]);

        $query->andFilterWhere(['like', 'name', $this->name])
            ->andFilterWhere(['like', 'invoice_status', $this->invoice_status])
            ->andFilterWhere(['like', 'qty_delivered_method', $this->qty_delivered_method])
            ->andFilterWhere(['like', 'state', $this->state])
            ->andFilterWhere(['like', 'display_type', $this->display_type])
            ->andFilterWhere(['like', 'warning_stock', $this->warning_stock])
           ;

        return $dataProvider;
    }
}
