<?php

namespace app\models;

use Yii;

/**
 * This is the model class for table "sale_order_line".
 *
 * @property int $id TRIAL
 * @property int $order_id TRIAL
 * @property string $name TRIAL
 * @property int|null $sequence TRIAL
 * @property string|null $invoice_status TRIAL
 * @property float $price_unit TRIAL
 * @property float|null $price_subtotal TRIAL
 * @property float|null $price_tax TRIAL
 * @property float|null $price_total TRIAL
 * @property float|null $price_reduce TRIAL
 * @property float|null $price_reduce_taxinc TRIAL
 * @property float|null $price_reduce_taxexcl TRIAL
 * @property float|null $discount TRIAL
 * @property int|null $product_id TRIAL
 * @property float $product_uom_qty TRIAL
 * @property int|null $product_uom TRIAL
 * @property string|null $qty_delivered_method TRIAL
 * @property float|null $qty_delivered TRIAL
 * @property float|null $qty_delivered_manual TRIAL
 * @property float|null $qty_to_invoice TRIAL
 * @property float|null $qty_invoiced TRIAL
 * @property float|null $untaxed_amount_invoiced TRIAL
 * @property float|null $untaxed_amount_to_invoice TRIAL
 * @property int|null $salesman_id TRIAL
 * @property int|null $currency_id TRIAL
 * @property int|null $company_id TRIAL
 * @property int|null $order_partner_id TRIAL
 * @property int|null $is_expense TRIAL
 * @property int|null $is_downpayment TRIAL
 * @property string|null $state TRIAL
 * @property float $customer_lead TRIAL
 * @property string|null $display_type TRIAL
 * @property int|null $create_uid TRIAL
 * @property string|null $create_date TRIAL
 * @property int|null $write_uid TRIAL
 * @property string|null $write_date TRIAL
 * @property int|null $product_packaging TRIAL
 * @property int|null $route_id TRIAL
 * @property int|null $linked_line_id TRIAL
 * @property string|null $warning_stock TRIAL
 * @property string|null $trial555 TRIAL
 *
 * @property ResCompany $company
 * @property ResUsers $createU
 * @property SaleOrderLine $linkedLine
 * @property SaleOrderLine[] $saleOrderLines
 * @property SaleOrder $order
 * @property ResPartner $orderPartner
 * @property ProductProduct $product
 * @property ResUsers $salesman
 * @property ResUsers $writeU
 */
class SaleOrderLine extends \yii\db\ActiveRecord
{
    /**
     * {@inheritdoc}
     */
    public static function tableName()
    {
        return 'sale_order_line';
    }

    /**
     * {@inheritdoc}
     */
    public function rules()
    {
        return [
            [['order_id', 'name', 'price_unit', 'product_uom_qty', 'customer_lead'], 'required'],
            [['order_id', 'sequence', 'product_id', 'product_uom', 'salesman_id', 'currency_id', 'company_id', 'order_partner_id', 'is_expense', 'is_downpayment', 'create_uid', 'write_uid', 'product_packaging', 'route_id', 'linked_line_id'], 'integer'],
            [['name', 'invoice_status', 'qty_delivered_method', 'state', 'display_type', 'warning_stock'], 'string'],
            [['price_unit', 'price_subtotal', 'price_tax', 'price_total', 'price_reduce', 'price_reduce_taxinc', 'price_reduce_taxexcl', 'discount', 'product_uom_qty', 'qty_delivered', 'qty_delivered_manual', 'qty_to_invoice', 'qty_invoiced', 'untaxed_amount_invoiced', 'untaxed_amount_to_invoice', 'customer_lead'], 'number'],
            [['create_date', 'write_date'], 'safe'],
            [['trial555'], 'string', 'max' => 1],
            [['company_id'], 'exist', 'skipOnError' => true, 'targetClass' => ResCompany::className(), 'targetAttribute' => ['company_id' => 'id']],
            [['create_uid'], 'exist', 'skipOnError' => true, 'targetClass' => ResUsers::className(), 'targetAttribute' => ['create_uid' => 'id']],
            [['linked_line_id'], 'exist', 'skipOnError' => true, 'targetClass' => SaleOrderLine::className(), 'targetAttribute' => ['linked_line_id' => 'id']],
            [['order_id'], 'exist', 'skipOnError' => true, 'targetClass' => SaleOrder::className(), 'targetAttribute' => ['order_id' => 'id']],
            [['order_partner_id'], 'exist', 'skipOnError' => true, 'targetClass' => ResPartner::className(), 'targetAttribute' => ['order_partner_id' => 'id']],
            [['product_id'], 'exist', 'skipOnError' => true, 'targetClass' => ProductProduct::className(), 'targetAttribute' => ['product_id' => 'id']],
            [['salesman_id'], 'exist', 'skipOnError' => true, 'targetClass' => ResUsers::className(), 'targetAttribute' => ['salesman_id' => 'id']],
            [['write_uid'], 'exist', 'skipOnError' => true, 'targetClass' => ResUsers::className(), 'targetAttribute' => ['write_uid' => 'id']],
        ];
    }

    /**
     * {@inheritdoc}
     */
    public function attributeLabels()
    {
        return [
            'id' => 'ID',
            'order_id' => 'Order ID',
            'name' => 'Name',
            'sequence' => 'Sequence',
            'invoice_status' => 'Invoice Status',
            'price_unit' => 'Price Unit',
            'price_subtotal' => 'Price Subtotal',
            'price_tax' => 'Price Tax',
            'price_total' => 'Price Total',
            'price_reduce' => 'Price Reduce',
            'price_reduce_taxinc' => 'Price Reduce Taxinc',
            'price_reduce_taxexcl' => 'Price Reduce Taxexcl',
            'discount' => 'Discount',
            'product_id' => 'Product ID',
            'product_uom_qty' => 'Product Uom Qty',
            'product_uom' => 'Product Uom',
            'qty_delivered_method' => 'Qty Delivered Method',
            'qty_delivered' => 'Qty Delivered',
            'qty_delivered_manual' => 'Qty Delivered Manual',
            'qty_to_invoice' => 'Qty To Invoice',
            'qty_invoiced' => 'Qty Invoiced',
            'untaxed_amount_invoiced' => 'Untaxed Amount Invoiced',
            'untaxed_amount_to_invoice' => 'Untaxed Amount To Invoice',
            'salesman_id' => 'Salesman ID',
            'currency_id' => 'Currency ID',
            'company_id' => 'Company ID',
            'order_partner_id' => 'Order Partner ID',
            'is_expense' => 'Is Expense',
            'is_downpayment' => 'Is Downpayment',
            'state' => 'State',
            'customer_lead' => 'Customer Lead',
            'display_type' => 'Display Type',
            'create_uid' => 'Create Uid',
            'create_date' => 'Create Date',
            'write_uid' => 'Write Uid',
            'write_date' => 'Write Date',
            'product_packaging' => 'Product Packaging',
            'route_id' => 'Route ID',
            'linked_line_id' => 'Linked Line ID',
            'warning_stock' => 'Warning Stock',
            'trial555' => 'Trial555',
        ];
    }

    /**
     * Gets query for [[Company]].
     *
     * @return \yii\db\ActiveQuery|ResCompanyQuery
     */
    public function getCompany()
    {
        return $this->hasOne(ResCompany::className(), ['id' => 'company_id']);
    }

    /**
     * Gets query for [[CreateU]].
     *
     * @return \yii\db\ActiveQuery|ResUsersQuery
     */
    public function getCreateU()
    {
        return $this->hasOne(ResUsers::className(), ['id' => 'create_uid']);
    }

    /**
     * Gets query for [[LinkedLine]].
     *
     * @return \yii\db\ActiveQuery|SaleOrderLineQuery
     */
    public function getLinkedLine()
    {
        return $this->hasOne(SaleOrderLine::className(), ['id' => 'linked_line_id']);
    }

    /**
     * Gets query for [[SaleOrderLines]].
     *
     * @return \yii\db\ActiveQuery|SaleOrderLineQuery
     */
    public function getSaleOrderLines()
    {
        return $this->hasMany(SaleOrderLine::className(), ['linked_line_id' => 'id']);
    }

    /**
     * Gets query for [[Order]].
     *
     * @return \yii\db\ActiveQuery|SaleOrderQuery
     */
    public function getOrder()
    {
        return $this->hasOne(SaleOrder::className(), ['id' => 'order_id']);
    }

    /**
     * Gets query for [[OrderPartner]].
     *
     * @return \yii\db\ActiveQuery|ResPartnerQuery
     */
    public function getOrderPartner()
    {
        return $this->hasOne(ResPartner::className(), ['id' => 'order_partner_id']);
    }

    /**
     * Gets query for [[Product]].
     *
     * @return \yii\db\ActiveQuery|ProductProductQuery
     */
    public function getProduct()
    {
        return $this->hasOne(ProductProduct::className(), ['id' => 'product_id']);
    }

    /**
     * Gets query for [[Salesman]].
     *
     * @return \yii\db\ActiveQuery|ResUsersQuery
     */
    public function getSalesman()
    {
        return $this->hasOne(ResUsers::className(), ['id' => 'salesman_id']);
    }

    /**
     * Gets query for [[WriteU]].
     *
     * @return \yii\db\ActiveQuery|ResUsersQuery
     */
    public function getWriteU()
    {
        return $this->hasOne(ResUsers::className(), ['id' => 'write_uid']);
    }

    /**
     * {@inheritdoc}
     * @return SaleOrderLineQuery the active query used by this AR class.
     */
    public static function find()
    {
        return new SaleOrderLineQuery(get_called_class());
    }
}
