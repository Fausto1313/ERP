<?php

namespace app\models;

use Yii;
class ProductTemplateAttributeValue extends \yii\db\ActiveRecord
{
    public static function tableName()
    {
        return 'product_template_attribute_value';
    }

    public function rules()
    {
        return [
            [['ptav_active', 'product_attribute_value_id', 'attribute_line_id', 'product_tmpl_id', 'attribute_id', 'create_uid', 'write_uid'], 'integer'],
            [['product_attribute_value_id', 'attribute_line_id'], 'required'],
            [['price_extra'], 'number'],
            [['create_date', 'write_date'], 'safe'],
            [['trial405'], 'string', 'max' => 1],
            [['product_attribute_value_id', 'attribute_line_id'], 'unique', 'targetAttribute' => ['product_attribute_value_id', 'attribute_line_id']],
            [['create_uid'], 'exist', 'skipOnError' => true, 'targetClass' => ResUsers::className(), 'targetAttribute' => ['create_uid' => 'id']],
            [['write_uid'], 'exist', 'skipOnError' => true, 'targetClass' => ResUsers::className(), 'targetAttribute' => ['write_uid' => 'id']],
        ];
    }

    public function attributeLabels()
    {
        return [
            'id' => 'ID',
            'ptav_active' => 'Ptav Active',
            'product_attribute_value_id' => 'Product Attribute Value ID',
            'attribute_line_id' => 'Attribute Line ID',
            'price_extra' => 'Price Extra',
            'product_tmpl_id' => 'Product Tmpl ID',
            'attribute_id' => 'Attribute ID',
            'create_uid' => 'Create Uid',
            'create_date' => 'Create Date',
            'write_uid' => 'Write Uid',
            'write_date' => 'Write Date',
            'trial405' => 'Trial405',
        ];
    }

    public function getProductTemplateAttributeExclusions()
    {
        return $this->hasMany(ProductTemplateAttributeExclusion::className(), ['product_template_attribute_value_id' => 'id']);
    }

    public function getCreateU()
    {
        return $this->hasOne(ResUsers::className(), ['id' => 'create_uid']);
    }

    public function getWriteU()
    {
        return $this->hasOne(ResUsers::className(), ['id' => 'write_uid']);
    }

    public static function find()
    {
        return new ProductTemplateAttributeValueQuery(get_called_class());
    }
}
