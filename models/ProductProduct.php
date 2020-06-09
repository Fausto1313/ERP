<?php

namespace app\models;

use Yii;

class ProductProduct extends \yii\db\ActiveRecord
{
    public static function tableName()
    {
        return 'product_product';
    }

    public function rules()
    {
        return [
            [['message_main_attachment_id', 'active', 'product_tmpl_id', 'can_image_variant_1024_be_zoomed', 'create_uid', 'write_uid'], 'integer'],
            [['default_code', 'barcode', 'combination_indices'], 'string'],
            [['product_tmpl_id'], 'required'],
            [['volume', 'weight'], 'number'],
            [['create_date', 'write_date'], 'safe'],
            [['trial375'], 'string', 'max' => 1],
            [['create_uid'], 'exist', 'skipOnError' => true, 'targetClass' => ResUsers::className(), 'targetAttribute' => ['create_uid' => 'id']],
            [['message_main_attachment_id'], 'exist', 'skipOnError' => true, 'targetClass' => IrAttachment::className(), 'targetAttribute' => ['message_main_attachment_id' => 'id']],
            [['write_uid'], 'exist', 'skipOnError' => true, 'targetClass' => ResUsers::className(), 'targetAttribute' => ['write_uid' => 'id']],
        ];
    }

    public function attributeLabels()
    {
        return [
            'id' => 'ID',
            'message_main_attachment_id' => 'Mensaje',
            'default_code' => 'Código',
            'active' => 'Activo',
            'product_tmpl_id' => 'Producto Temmplate ID',
            'barcode' => 'Código de Barras',
            'combination_indices' => 'Combinacion Indices',
            'volume' => 'Volumen',
            'weight' => 'Peso',
            'can_image_variant_1024_be_zoomed' => 'Can Image Variant 1024 Be Zoomed',
            'create_uid' => 'Create Uid',
            'create_date' => 'Create Date',
            'write_uid' => 'Write Uid',
            'write_date' => 'Write Date',
            'trial375' => 'Trial375',
        ];
    }

    public function getCreateU()
    {
        return $this->hasOne(ResUsers::className(), ['id' => 'create_uid']);
    }

    public function getMessageMainAttachment()
    {
        return $this->hasOne(IrAttachment::className(), ['id' => 'message_main_attachment_id']);
    }

    public function getWriteU()
    {
        return $this->hasOne(ResUsers::className(), ['id' => 'write_uid']);
    }

    public function getSaleOrderLines()
    {
        return $this->hasMany(SaleOrderLine::className(), ['product_id' => 'id']);
    }

    public static function find()
    {
        return new ProductProductQuery(get_called_class());
    }
}
